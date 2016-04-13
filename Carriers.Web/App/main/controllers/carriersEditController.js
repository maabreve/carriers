(function (module) {

    var carriersEditController = function ($state, $timeout, $filter, $log, $stateParams, carriersService, accountService) {

        var model = this;
        //inicializacao de variaveis
        model.carrier = {};
        model.title = $stateParams.id === '' ? "New Carrier" : "Edit Carrier";
        model.canAddRating = $stateParams.id === '' ? false : true;
        
        //navegacao
        model.goToList = function () {
            $state.go('carriers-list');
        }

        //edit
        if ($stateParams.id !== '') {
            carriersService.get($stateParams.id)
                .then(function (carrier) {
                    model.carrier.Id = carrier.Id;
                    model.carrier.Name = carrier.Name;
                    model.carrier.Description = carrier.Description;
                });

            //ratings
            carriersService.getRatings($stateParams.id)
                .then(function (ratings) {
                    model.ratings = ratings;
                    if (ratings !== undefined && ratings !== null){
                        accountService.getCurrentUserId()
                           .then(function (userid) {
                               for (var x = 0; x < ratings.length; x++) {
                                   if (ratings[x].UserId == userid) {
                                       model.canAddRating = false;
                                       break;
                                   }
                               }
                           });
                    }
                });
        }

        //submit
        model.submitForm = function (name, description, isValid) {
            if (!isValid) {
                return;
            }

            if ($stateParams.id === '') {
                carriersService.post(name, description).then(function (data) {
                    model.carrier.Id = data.Id;
                    model.carrier.Name = data.Name;
                    model.carrier.Description = data.Description;
                    model.canAddRating = true;
                    $stateParams.id = data.Id;
                    }
                );
            }
            else {
                carriersService.put($stateParams.id, name, description).then(function () {
                        model.goToList();
                    }
                );
            }
        }


        //rating
        model.submitRating = function () {

            accountService.getCurrentUser().then(
                function (user) {
                    carriersService.postRating($stateParams.id, model.ratingValue, model.ratingComment, user.UserId, user.UserName).then(
                        function () {
                            model.canAddRating = false;
                            //carrega Ratings
                            carriersService.getRatings($stateParams.id)
                                .then(function (ratings) {
                                    model.ratings = ratings;
                                });

                        });
                })
        }
    };

    module.controller("carriersEditController", carriersEditController);

}(angular.module("mainApp")));
