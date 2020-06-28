﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Boot.Enums;
using Boot.Helpers;
using Boot.Models;
using Boot.Models.JsonModels;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using Rotativa;

namespace Boot.Controllers
{
    public class BaseController : Controller
    {
        protected void SaveCookie(CookieType t, string data) =>
            Response.Cookies.Add(CreateCookie(t.ToString().ToLower(), data));

        protected string GetCookie(CookieType t) => Request.Cookies[t.ToString().ToLower()]?.Value;

        private HttpCookie CreateCookie(string name, string data, int hours = 24) =>
            new HttpCookie(name) { Value = data, Expires = DateTime.Now.AddHours(hours) };

        protected JsonResult ReturnJson(string partial, string url, string status = null) =>
            Json(new { url, partial, status }, 0);

        protected T GetJsonFromFile<T>(string fileName)
        {
            var path = Server.MapPath($"~/App_Data/{fileName}");
            var json = System.IO.File.ReadAllText(path, Encoding.UTF8);
            return JsonConvert.DeserializeObject<T>(json);
        }

        protected void SaveJsonToFile<T>(T obj, string fileName)
        {
            var path = Server.MapPath($"~/App_Data/{fileName}");
            var content = JsonConvert.SerializeObject(obj);
            System.IO.File.WriteAllText(path, content, Encoding.UTF8);
        }

        protected void AddModelStateErrors(ServiceResponse response)
        {
            if (response.Successful()) return;
            foreach (var error in response.Errors)
                ModelState.AddModelError(error.Key, error.Error);
        }

        protected void SaveRotativa(ViewAsPdf pdf, string path)
        {
            var byteArray = pdf.BuildFile(ControllerContext);
            var fileStream = new FileStream(path, FileMode.Create, FileAccess.Write);
            fileStream.Write(byteArray, 0, byteArray.Length);
            fileStream.Close();
        }

        protected List<MagicSchoolGroup> GetMagicSchoolGroups()
        {
            var list = GetJsonFromFile<List<MagicSchoolGroup>>(FileNames.MagicSchools);
            var stats = GetJsonFromFile<List<Stat>>(FileNames.Stats);
            var spells = GetJsonFromFile<List<Spell>>(FileNames.Spells);
            foreach (var ms in list)
            {
                ms.Stat = stats.Single(x => x.Id == ms.StatId);
                foreach (var s in ms.Schools)
                    s.Spells = spells.Where(x => x.School == s.Id).OrderBy(x => x.Level).ToList();
            }
            return list;
        }

        protected SkillGroupList GetSkillGroupList()
        {
            var skillGroups = GetJsonFromFile<List<SkillGroup>>(FileNames.Skills);
            var stats = GetJsonFromFile<List<Stat>>(FileNames.Stats);
            foreach (var group in skillGroups)
                foreach (var skill in group.skills)
                    skill.Stat = stats.Single(x => x.Id == skill.StatId);
            return new SkillGroupList { Groups = skillGroups }; ;
        }

        protected List<Perk> GetPerks()
        {
            var perks = GetJsonFromFile<List<Perk>>(FileNames.Perks);
            var races = GetJsonFromFile<List<Race>>(FileNames.Races);
            var stats = GetJsonFromFile<List<Stat>>(FileNames.Stats);
            ViewBag.MaxLevel = perks
                .Max(x => x.requirements.Single(y => y.type == RequirementType.Level)
                .value);

            perks.SelectMany(perk => perk.requirements)
                .Where(req => req.type == RequirementType.Race)
                    .ForEach(req => req.strValue = races.Single(x => x.id == req.value).name);

            perks.SelectMany(perk => perk.requirements)
                .Where(req => req.type == RequirementType.Stat)
                    .ForEach(req => req.strValue = stats.Single(x => x.Id == req.statId).Name);

            return perks;
        }
    }
}