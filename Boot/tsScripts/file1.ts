/// <reference path="../Scripts/typings/jquery/jquery.d.ts" />

function welcome(person: string) {
    return `Hello ${person}, Lets learn TypeScript`;
}

function clickMeButton() {
    const user = "V";
    $("#divMsg").text(welcome(user));
}