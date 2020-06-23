function heroStatsInit(statsCount) {
    console.log(2);
    var heroStats = new Vue({
        el: "#heroStats",
        data: {
            editable: true,
            statsCount: statsCount
        },
        methods: {
            load: function () {
                hero = MainJs.getCookie("hero");
                this.editable = hero.Stage == Stage.Stats;
                console.log(hero);
                if (!hero.Stats) {
                    hero.Stats = [];
                    for (var i = 0; i < statsCount; i++)
                        hero.Stats[i] = 8;
                    MainJs.setCookie("hero");
                }
            }
        },
        beforeMount() {
            this.load();
        },
    });
}