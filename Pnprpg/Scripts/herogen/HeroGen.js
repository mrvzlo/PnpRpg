const Stage = Object.freeze({ Chaos: 1, Stats: 2, Skills: 3, Traits: 4, Perks: 5, Spells: 6, Result: 7 });
const startStage = Stage.Stats;

function heroGenInit(stageLinks) {
    var heroGen = new Vue({
        el: "#heroGen",
        data: {
            message: "Старт",
            hero: {},
            stageContent: "",
        },
        methods: {
            load: function () {
                hero = MainJs.getCookie("hero");
                if (!hero.Stage) {
                    hero = {};
                    hero.Stage = startStage;
                    MainJs.setCookie("hero");
                }
            },
            ready() {
                var url = stageLinks[hero.Stage];
                axios.get(url).then(response => {
                    this.stageContent = response.data;
                })
            }
        },
        beforeMount() {
            this.load();
            this.ready();
        }
    });
}
