
function GetBranchAll($http, $q)
{
    // Get the deferred object
    var deferred = $q.defer();
    // Initiates the AJAX call
    $http({ method: 'GET', url: '/branch/GetBranches' }).success(deferred.resolve).error(deferred.reject);
    // Returns the promise - Contains result once request completes
    return deferred.promise;

}