import AxiosPack from "@/scripts/AxiosPack.js";

const baseUrl = process.env.API_ROOT;
const snailFisUrls = {
    SysUser:{
        AddUser:"/SysUser/AddUser",
        UpdateUser:"/SysUser/UpdateUser",
        UserLogin:"/SysUser/UserLogin",
        RefreshToken:"/SysUser/RefreshToken",
    },
    Test:{
        GetBankList:"get /Test/GetBankList",
    }
};
const { $get, $post } = AxiosPack;
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
