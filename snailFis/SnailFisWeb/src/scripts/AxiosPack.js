import Vue from 'vue'
import axios from 'axios'
import VueAxios from 'vue-axios'
import {Message} from 'element-ui'
import qs from "qs";
import router from '@/router'
import store from '@/store/store.js'
 
Vue.use(VueAxios, axios)
//消息提示
const tip = (errorStr)=>{
    Message.error({message: errorStr});
}

/** 
 * 跳转登录页
 * 携带当前页面路由，以期在登录页面完成登录后返回当前页面
 */
const toLogin = () => {
  console.log(router);
  router.push('/Login');
}

// 请求拦截器
axios.interceptors.request.use(
    config => {
        // 在发送请求之前做些什么(后期在这里加上token)
        const token = store.state.TokenInfo.accesstoken;
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
                case 400: tip('请求错误(400)'); break;
                case 401: tip('未授权，请重新登录(401)'); 
                setTimeout(() => {
                    toLogin();
                }, 1000);
                break;
                case 403: tip('未知错误(403)'); break;
                case 404: tip('请求出错(404)'); break;
                case 408: tip('请求超时(408)'); break;
                case 500: tip('服务器错误(500)'); break;
                case 501: tip('服务未实现(501)'); break;
                case 502: tip('网络错误(502)'); break;
                case 503: tip('服务不可用(503)'); break;
                case 504: tip('网络超时(504)'); break;
                case 505: tip('HTTP版本不受支持(505)'); break;
                default: tip('连接出错'); break;
            }
        } else {
            tip('连接服务器失败!');
        }
      return Promise.resolve(error);
    }
)

export default {
    $get(url, data, completedFunc) {
      let http = axios.get(url, { params: data });
      if (completedFunc) {
        http.then(completedFunc);
      } else {
        return http;
      }
    },
    $postJson(url, data, completedFunc) {
      let _qsData = JSON.stringify(data);
      let http = axios.post(url, _qsData, {
        headers: {
          "Content-Type": "application/json; charset=utf-8"
        }
      });
      if (completedFunc) {
        http.then(completedFunc);
      } else {
        return http;
      }
    },
    $post(url, data, completedFunc) {
      let _qsData = qs.stringify(data, {
        arrayFormat: "indices"
      });
      let http = axios.post(url, _qsData);
      if (completedFunc) {
        http.then(completedFunc);
      } else {
        return http;
      }
    },
    $postFile(url, form) {
      let config = {
        headers: {
          "Content-Type": "multipart/form-data"
        }
      };
      let http = axios.post(url, form, config);
      return http;
    },
    $getFile(url, form) {
      let config = {
        headers: {
          "content-disposition": "attachment; filename=total.xls",
          "content-type": "application/x-download;charset=utf-8"
        }
      };
      let _qsData = qs.stringify(form, {
        arrayFormat: "indices"
      });
      let http = axios.post(url, _qsData, {
        responseType: "blob",
      });
      return http;
    }
  };