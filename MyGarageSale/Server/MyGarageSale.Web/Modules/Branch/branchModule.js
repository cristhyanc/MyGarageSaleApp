
//var branchModule = angular.module("branchModule", ['ngRoute']);

var branchModule = angular.module("branchModule", ["ngRoute"]);

branchModule.config(function ($routeProvider, $locationProvider) {
 //Path - it should be same as href link
    $routeProvider.when('/Branch/AddBranch', { templateUrl: '/Branch/AddBranch', controller: 'branchController' });
    $routeProvider.when('/Branch/List', { templateUrl: '/Branch/List', controller: 'branchController' });
        $routeProvider.otherwise(
                               {

                                   controller: "branchController",
                                   templateUrl
                                       : "/Branch/List"
                               });

    $locationProvider.html5Mode({
        enabled: true,
        requireBase: false
    });
 });

//branchModule.config(['$routeProvider', '$locationProvider', function ($routeProvider, $locationProvider) {

//    //Angular Pages
//    $routeProvider.when('/showartists',
//                        {
//                            templateUrl: 'Branch/AddBranch',
//                            controller: 'branchController'
//                        });
//    //$routeProvider.otherwise(
//    //                       {

//    //                           controller: "MainCtrl",
//    //                           template: "<div></div>"
//    //                       });
//    $locationProvider.html5Mode({
//        enabled: true,
//        requireBase: false
//    });
//}]);

branchModule.factory("BranchService", function ($http, $q) {
    return {
        getBranches: GetBranchAll($http, $q),

        //addTalk: function (talk) {
        //    // Get the deferred object
        //    var deferred = $q.defer();
        //    // Initiates the AJAX call
        //    $http({ method: 'POST', url:'/events/AddTalk', data: talk }).success(deferred.resolve).error(deferred.reject);
        //    // Returns the promise - Contains result once request completes
        //    return deferred.promise;
        //}

    }
    
});

branchModule.controller("branchController", function ($scope, $location, BranchService) {
    BranchController($scope, $location, BranchService);
});



function BranchController($scope, $location, BranchService)
{
    $scope.RomeoShebo="hello word!";
    //Get all branches
    BranchService.getBranches.then(function (branches) {
        $scope.branches = branches;
    }, function (ex)
    {alert(ex); RegisterError('error while fetching talks from server', 'Branch'); });


    //$scope.add = function (talk) {
    //    BranchService.addTalk(talk).then(function () { $location.url('/Events/Talks'); }, function ()
    //    { alert('error while adding talk at server') });
    //};
}

//var eventModule = angular.module("eventModule", ['ngRoute']).config(function ($routeProvider) {
//    //Path - it should be same as href link
//    $routeProvider.when('/Talks', { templateUrl: '/Templates/Talk.html', controller: 'eventController' });
//    $routeProvider.when('/Speakers', { templateUrl: '/Templates/Speaker.html', controller: 'speakerController' });
//});

//eventModule.controller("talkController", function ($scope, $location, EventsService) {
    
//});

