import AxiosPack from "@/scripts/AxiosPack.js";
// const baseUrl = "http://39.101.181.95:8080/snailFis_api";
const baseUrl = "http://localhost:63834/snailFis_api";
const snailFisUrls = {
    Dictionarys: {
        GetDicList:"get /Dictionarys/GetDicList",
    },
    SysUser:{
        AddUser:"/SysUser/AddUser",
        UpdateUser:"/SysUser/UpdateUser",
        UserLogin:"/SysUser/UserLogin",
        RefreshToken:"/SysUser/RefreshToken",
    }
};
const { $get, $postJson, $post, $getFile, $postFile } = AxiosPack;
let allAxios = {};

function convertUrls(urls, key) {
    allAxios[key] = {};
    const sUrl = urls[key];
    for (const uKey in urls) {
        if (urls.hasOwnProperty(uKey)) {
        allAxios[key][uKey] = function (args) {
            let __urlSplits = urls[uKey].split(" ");
            if (__urlSplits.length >= 2) {
            switch (__urlSplits[0]) {
                case "get":
                return $get(baseUrl + __urlSplits[1], args);
                case "getFile":
                return $getFile(baseUrl + __urlSplits[1], args);
                case "postFile":
                return $postFile(baseUrl + __urlSplits[1], args);
                case "postUrl":
                return $post(baseUrl + __urlSplits[1] + args);
                case "postJson":
                return $postJson(baseUrl + __urlSplits[1], args);
                default:
                return $post(baseUrl + urls[uKey], args);
            }
            } else {
            return $post(baseUrl + urls[uKey], args);
            }
      };
    }
  }
}
for (const key in snailFisUrls) {
  convertUrls(snailFisUrls[key], key);
}
export default allAxios;
