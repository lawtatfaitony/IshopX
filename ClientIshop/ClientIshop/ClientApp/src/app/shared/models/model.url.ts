export const apiHostName = {
  onlineHost: "http://www.tony123.top/ng/",
  offLineHost: "http://192.168.0.177:8082/",        
  defaultHost: "http://localhost:8082/",   //  : "/ng/"   //http://192.168.3.52:82/
  onlineImgHost: "http://81.71.74.135:8081/"
};

export const apiUrls = {
  weatherforecasts: apiHostName.defaultHost + 'SampleData/WeatherForecasts',
  ipstatitic: apiHostName.defaultHost  + "IPcounter/IPstatitics/",
  getinfoids: apiHostName.defaultHost + "InfoData/getinfoids/", // compound infodetails
  InfoDetailRalateList: apiHostName.defaultHost +  "InfoData/InfoDetailRalateList/",
  shopstaffdetails: apiHostName.defaultHost + 'InfoData/ShopStaffDetails/',
  shopdetails: apiHostName.defaultHost + 'InfoData/ShopDetails/',
  pageLoadingTimesCounter: apiHostName.defaultHost + "IPcounter/PageLoadingTimesCounter/",
  getInfolist: apiHostName.defaultHost + "InfoData/GetInfolist/",
  getInfoPaneAdSet: apiHostName.defaultHost + "InfoData/getInfoPaneAdSet/"
 
};
