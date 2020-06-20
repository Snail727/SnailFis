<template>
  <div>
      <el-input v-model="login.Phone" placeholder="请输入手机号"></el-input>手机号<br/>
      <el-input v-model="login.PassWord" placeholder="请输入密码" type="PassWord"></el-input>密码<br/>
      <el-button @click="UserLogin">登陆</el-button>
  </div>
</template>

<script>
export default {
    components:{},
    data(){
        return{
            login:{
                Phone:"",
                PassWord:"",
            }
        }
    },
    methods:{
        UserLogin(){
            var self =this;
            self.$allAxios.SysUser.UserLogin(self.login).then((res)=>{
                self.UpdateToken(res.Data);//更新token
                self.$router.push('/');//跳转首页
            });
        }
    }
}
</script>