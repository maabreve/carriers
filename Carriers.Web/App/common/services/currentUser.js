(function (module) {

    var USERKEY = "utoken";

    var currentUser = function (localStorage) {

        var saveUser = function () {
            localStorage.add(USERKEY, profile);
        };

        var removeUser = function () {
            localStorage.remove(USERKEY);
        };


        var initialize = function () {
            var user = {
                username: "",
                firstname: "",
                token: "",
                iToken: "",
                workflow: [],
                get loggedIn() {
                    return this.token ? true : false;
                }
            };

            var localUser = localStorage.get(USERKEY);
            if (localUser) {
                user.username = localUser.username;
                user.firstname = localUser.firstname;
                user.token = localUser.token;
                user.iToken = localUser.iToken;
            }


            return user;
        }

        var encKey = 'MusicAndHappiness';

        var profile = initialize();

        return {
            save: saveUser,
            remove: removeUser,
            profile: profile,
            encKey: encKey
        };
    };

    module.factory("currentUser", currentUser);

}(angular.module("common")));