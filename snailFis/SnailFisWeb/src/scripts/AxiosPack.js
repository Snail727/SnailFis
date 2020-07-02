import Vue from 'vue'
import axios from 'axios'
import vueAxios from 'vue-axios'
import qs from "qs";
import operateToken from "./OperateToken.js";
const {tip,toLogin,refresh} =operateToken;
Vue.use(vueAxios, axios)

// 请求拦截器
axios.interceptors.request.use(
    config => {
        var timestamp = Date.parse(new Date())/1000;

        var tokenDataStr =localStorage.getItem('token');
        var tokenData={Exp:0,Accesstoken:""};
        if(tokenDataStr!=null){tokenData=JSON.parse(tokenDataStr);}
        
        var exp = tokenData.Exp;
        var lastDate = exp-timestamp;
        //token过期时间三十分钟以内获取刷新token
        if(lastDate>0 & lastDate<1800 & config.url.indexOf("SysUser/RefreshToken") == -1){
          refresh();
        }
        // 在发送请求之前做些什么(在这里加上token)
        var token = tokenData.Accesstoken;
        token && (config.headers.Authorization = token);  
        return config;
    },
    error => {
        // 对请求错误做些什么
        return Promise.reject(error);
    }
)

// 响应拦截器
axios.interceptors.response.use(
    // 请求成功
    (res) => {
        if(res.status === 200) {
            return Promise.resolve(res.data);
        } else {
            return Promise.reject(res);
        }
    },
    // 请求失败
    error => {
      if (error && error.response) {
          switch (error.response.status) {
              case 401: tip('未授权，请重新登录(401)'); 
              setTimeout(() => {
                  toLogin();
              }, 1000);
              break;
              case 404: tip('页面走丢了(404)'); break;
              default: tip('连接出错'); break;
          }
      }
      return Promise.resolve(error);
    }
)

export default {
    $get(url, data) {
      return axios.get(url, { params: data });
    },
    $post(url, data, completedFunc) {
      let _qsData = qs.stringify(data, {
        arrayFormat: "indices"
      });
      let http = axios.post(url, _qsData);
      return http;
    }
};