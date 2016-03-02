(function () {
    "use strict";

    angular.module("app-trips")
        .controller("tripsController", tripsController);

    function tripsController($http) {
        var vm = this;

        vm.name = "My name";

        vm.trips = [];

        vm.newTrip = {};

        vm.errorMessage = "";
        vm.isBusy = true;

        $http.get("/api/trips")
            .then(function () {
                angular.copy(response.data, vm.trips);
            }, function (error) {
                vm.errorMessage = "Failed to load resources. " + error;
            })
            .finally(function () {
                vm.busy = false;
            });

        vm.addTrip = function () {
            //vm.trips.push({ name: vm.newTrip.name, created: new Date() });
            //vm.newTrip = {};

            vm.isBusy = true;
            vm.errorMessage = "";

            $http.post("/api/trips", vm.newTrip)
            .then(function () {
                vm.trip.push(response.data);
                vm.newTrip = {};
            }, function () {
                vm.errorMessage = "Failed to save new trip.";
            })
            .finally(function () {
                vm.isBusy = false;
            });
        };


    }
})();