angular.module('MyApp', ['ngMaterial', 'ngMessages', 'material.svgAssetsCache'])
.config(function($mdIconProvider) {
    $mdIconProvider
      .icon('share', 'img/icons/baseline-share-24px.svg', 24)
      .icon('upload', 'img/icons/upload.svg', 24)
      .icon('copy', 'img/icons/copy.svg', 24)
      .icon('print', 'img/icons/print.svg', 24)
  })
.controller('BottomSheetExample', function($scope, $timeout, $mdBottomSheet, $mdToast) {
  $scope.alert = 'HELLO'; 

  $scope.showListBottomSheet = function() {
    $scope.alert = 'CLICK';
    $mdBottomSheet.show({
      templateUrl: 'bottom-sheet-list-template.html',
      controller: 'ListBottomSheetCtrl'
      }).then(function(clickedItem) {
      $scope.alert = clickedItem['name'] + ' clicked!';
    }).catch(function(error) {
      // User clicked outside or hit escape
    });
  };
})
.controller('ListBottomSheetCtrl', function($scope, $mdBottomSheet) {

  $scope.items = [
    { name: 'ZAP', icon: 'share' },
    { name: 'SMS', icon: 'upload' },
    { name: 'E-mail', icon: 'copy' },
    { name: 'Chat', icon: 'print' },
  ];

  $scope.listItemClick = function($index) {
    var clickedItem = $scope.items[$index];
    $mdBottomSheet.hide(clickedItem);
  };
});