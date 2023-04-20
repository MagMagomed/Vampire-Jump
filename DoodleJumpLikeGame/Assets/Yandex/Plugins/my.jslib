mergeInto(LibraryManager.library, {

  HelloWorld: function () {
    try {
      player.getData().then(_data => {
        console.log('////////////////////////////////////////////////////////////\n', _data, '\n////////////////////////////////////////////////////////////');
      })
    }
    catch (e) {
      console.log(e);
    }
  },

  WhoAreYou: function () {
    var name = prompt("Как тебя зовут, вампир?");
    return name;
  },

  Hello: function (name) {
    window.alert("Hello, " + UTF8ToString(name) + "!");
  },

  AddNewRecord: function (newRecord) {
    ysdk.isAvailableMethod('leaderboards.setLeaderboardScore').then(isAvailable => {
      if (isAvailable) {
        ysdk.getLeaderboards().then(ld => 
          ld.setLeaderboardScore('myFirstLeaderBord', newRecord));
      }
    })
  },
  ShowFullScreenAds : function () {
    ysdk.adv.showFullscreenAdv();
  }
});