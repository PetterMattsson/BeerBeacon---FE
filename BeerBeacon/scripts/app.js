
function initMap() {
    globalApp.initMap();    
}

var globalApp = (function () {
  'use strict';

  var app = {
    isLoading: true,
    spinner: document.querySelector('.loader'),
    cardTemplate: document.querySelector('.cardTemplate'),
    container: document.querySelector('.main'),
    addDialog: document.querySelector('.dialog-container'),  
    /*Petters klydd börjar här*/
    map: document.querySelector('#map'),
    beerTimer: 0
  };


  /*****************************************************************************
   *
   * Event listeners for UI elements
   *
   ****************************************************************************/
   //open beacon dialog 
  document.getElementById('addBeacon').addEventListener('click', function () {
      //open the place beacon dialog
      app.toggleAddDialog(true);
  });

  //add beer
  document.getElementById('btnAddBeer').addEventListener('click', function () {
      var e = document.getElementById("numberOfBeers");
      var beers = e.options[e.selectedIndex].value;
      app.addBeer(parseInt(beers));
      app.toggleAddDialog(false);
      var display = document.querySelector('.footer-title');
      app.initBeerTimer(app.beerTimer * 60, display);
  });
    //Close beacon dialog
  document.getElementById('btnAddCancel').addEventListener('click', function () {
        //hide add beer dialog 
      app.toggleAddDialog(false);
  });
  
    
    /**************************************************************************
    / Maps
    ***************************************************************************/

  //Move mapps into app context
  app.initMap = function () {

      // Note: This example requires that you consent to location sharing when
      // prompted by your browser. If you see the error "The Geolocation service
      // failed.", it means you probably did not give permission for the browser to
      // locate you.
      var map, infoWindow;
      
          map = new google.maps.Map(document.getElementById('map'), {
              center: { lat: -34.397, lng: 150.644 },
              zoom: 6,
              disableDefaultUI: true
          });
          infoWindow = new google.maps.InfoWindow;

          // Try HTML5 geolocation.
          if (navigator.geolocation) {
              navigator.geolocation.getCurrentPosition(function (position) {
                  var pos = {
                      lat: position.coords.latitude,
                      lng: position.coords.longitude
                  };

                  infoWindow.setPosition(pos);
                  infoWindow.setContent('Location found.');
                  infoWindow.open(map);
                  map.setCenter(pos);
              }, function () {
                  handleLocationError(true, infoWindow, map.getCenter());
              });
          } else {
              // Browser doesn't support Geolocation
              handleLocationError(false, infoWindow, map.getCenter());
          }
      

      function handleLocationError(browserHasGeolocation, infoWindow, pos) {
          infoWindow.setPosition(pos);
          infoWindow.setContent(browserHasGeolocation ?
              'Error: The Geolocation service failed.' :
              'Error: Your browser doesn\'t support geolocation.');
          infoWindow.open(map);
      }
 

      app.spinner.setAttribute('hidden', true);
  };

    /**************************************************************************
    / Location
    ***************************************************************************/


    /*https://developers.google.com/web/fundamentals/native-hardware/user-location/ */

  /*****************************************************************************
   *
   * Methods to update/refresh the UI
   *
   ****************************************************************************/

  // Toggles the visibility of the add new city dialog.
  app.toggleAddDialog = function(visible) {
    if (visible) {
      app.addDialog.classList.add('dialog-container--visible');
    } else {
      app.addDialog.classList.remove('dialog-container--visible');
    }
  };

    //Updates number of beers selected
  app.addBeer = function (numberOfBeers) {
      app.beerTimer = app.beerTimer + numberOfBeers;
  };

//Initiate beer timer
  app.initBeerTimer = function (duration, display) {
      var timer = duration, minutes, seconds;
      setInterval(function () {
          minutes = parseInt(timer / 60, 10);
          seconds = parseInt(timer % 60, 10);

          minutes = minutes < 10 ? "0" + minutes : minutes;
          seconds = seconds < 10 ? "0" + seconds : seconds;

          display.textContent = minutes + ":" + seconds;

          if (--timer < 0) {
              timer = duration;
          }
      }, 1000);
  };

/*****************************************************************************
   *
   * Methods to handle FB login
   *
   ****************************************************************************/
    /*

    // This is called with the results from from FB.getLoginStatus().
  app.statusChangeCallback = function (response) {
      console.log('statusChangeCallback');
      console.log(response);
      // The response object is returned with a status field that lets the
      // app know the current login status of the person.
      // Full docs on the response object can be found in the documentation
      // for FB.getLoginStatus().
      if (response.status === 'connected') {
          // Logged into your app and Facebook.
          app.apptestAPI();
      } else {
          // The person is not logged into your app or we are unable to tell.
          document.getElementById('status').innerHTML = 'Please log ' +
              'into this app.';
      }
  }

  // This function is called when someone finishes with the Login
  // Button.  See the onlogin handler attached to it in the sample
  // code below.
  app.checkLoginState = function () {
      FB.getLoginStatus(function (response) {
          app.statusChangeCallback(response);
      });
  }

  app.fbAsyncInit = function () {
      FB.init({
          appId: '{142753539618436}',
          cookie: true,  // enable cookies to allow the server to access 
          // the session
          xfbml: true,  // parse social plugins on this page
          version: 'v2.8' // use graph api version 2.8
      });

      // Now that we've initialized the JavaScript SDK, we call 
      // FB.getLoginStatus().  This function gets the state of the
      // person visiting this page and can return one of three states to
      // the callback you provide.  They can be:
      //
      // 1. Logged into your app ('connected')
      // 2. Logged into Facebook, but not your app ('not_authorized')
      // 3. Not logged into Facebook and can't tell if they are logged into
      //    your app or not.
      //
      // These three cases are handled in the callback function.

      FB.getLoginStatus(function (response) {
          app.statusChangeCallback(response);
      });

  };

  // Load the SDK asynchronously
  (function (d, s, id) {
      var js, fjs = d.getElementsByTagName(s)[0];
      if (d.getElementById(id)) return;
      js = d.createElement(s); js.id = id;
      js.src = "//connect.facebook.net/en_US/sdk.js";
      fjs.parentNode.insertBefore(js, fjs);
  }(document, 'script', 'facebook-jssdk'));

  // Here we run a very simple test of the Graph API after login is
  // successful.  See statusChangeCallback() for when this call is made.
  app.testAPI = function () {
      console.log('Welcome!  Fetching your information.... ');
      FB.api('/me', function (response) {
          console.log('Successful login for: ' + response.name);
          document.getElementById('status').innerHTML =
              'Thanks for logging in, ' + response.name + '!';
      });
  }
    */
  
  if ('serviceWorker' in navigator) {
    navigator.serviceWorker
             .register('./service-worker.js')
             .then(function() { console.log('Service Worker Registered'); });
  }

  

  return app;

})();
