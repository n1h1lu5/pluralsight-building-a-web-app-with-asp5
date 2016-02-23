(function () {
    "use strict";

    angular.module("app-trips")
        .controller("tripsController", tripsController);

    function tripsController() {
        var vm = this;

        vm.name = "My name";

        vm.trips = [
            {
                name: "us trip",
                created: new Date()
            },
            {
                name: "a trip",
                create: new Date()
            }
        ]
    }
})();