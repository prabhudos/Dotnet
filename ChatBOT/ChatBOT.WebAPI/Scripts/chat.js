(function () { // Angular encourages module pattern, good!
    var app = angular.module('myApp', []);

    var url = 'http://localhost:65460/api/chat';
    var hub = $.connection.chatHub; // create a proxy to signalr hub on web server

    app.controller('myCtrl', ['$http', '$scope', function ($http, $scope) {

        //Gets message from HUB
        hub.client.broadcastMessage = function (name, message) {
            $('#discussion').append('<li><strong>' + name + '</strong>: ' + message + '</li>');
        }

        //Join a chat
        $scope.join = function (message) {
            hub.server.join($scope.room);
        }

        //Leave a chat
        $scope.leave = function (message) {
            hub.server.leave($scope.room);
        }

        //Send message to chat
        $scope.send = function (message) {
            url += '?room=' + $scope.room + '&name=' + $scope.name + '&message=' + message;

            $http.post(url)
                .success(function (data, status) {
                })
                .error(function (data, status) {
                });
        }

        $.connection.hub.start(); // connect to signalr hub
    }]);
})();