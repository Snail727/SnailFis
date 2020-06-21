import {Message} from 'element-ui'
import router from '@/router'
import axios from 'axios'

export default {
    //消息提示
    tip(errorStr){
        Message.error({message: errorStr});
    },
    /*
    跳转登录页
    携带当前页面路由，以期在登录页面完成登录后返回当前页面
    */
    toLogin(){
        router.push('/Login');
    },
    //刷新token
    refresh(){
    var refreshtoken = JSON.parse(localStorage.getItem('token')).Refreshtoken;
    var url = process.env.API_ROOT + '/SysUser/RefreshToken';
    let _qsData = JSON.stringify({RefreshToken: refreshtoken});
    axios.post(url, _qsData, {
      headers: {
        "Content-Type": "application/json; charset=utf-8"
      }
    }).then((result) => {
      if(result.Success){
        localStorage.setItem('token', JSON.stringify(res.Data));
      }
      else{
        setTimeout(() => {
            toLogin();
        }, 1000);
      }
    }).catch(() => {
      setTimeout(() => {
          toLogin();
      }, 1000);
    });
  }
}