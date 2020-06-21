<template>
  <div :style="styleObject">
      <el-button style="float:right" type="primary" @click="registerVisible=true">注 册</el-button>
      <el-button style="float:right;margin-right:20px" type="primary" @click="loginVisible=true">登 陆</el-button>
      <el-dialog
        title="登录"
        :visible.sync="loginVisible"
        width="30%">
        <div>
            <div class="form-group" style="height: 28px;margin-bottom:12px;">
                <label style="width:70px;float:left;line-height:30px;text-align:right;margin-right:10px;">手机号:</label>
                <div style="width:80%;float:left;">
                    <el-input size="mini" v-model.trim="login.Phone" placeholder="请输入手机号" maxlength="64" />
                </div>
            </div>
            <div class="form-group" style="height: 28px;margin-bottom:12px;">
                <label style="width:70px;float:left;line-height:30px;text-align:right;margin-right:10px;">密码:</label>
                <div style="width:80%;float:left;">
                    <el-input size="mini" v-model.trim="login.PassWord" type="PassWord" placeholder="请输入密码" maxlength="64" />
                </div>
            </div>
            <div class="form-group" style="height: 28px;margin-bottom:12px;">
                <el-button type="primary" style="width:60%;margin-left:20%;" @click="UserLogin">登 陆</el-button>
            </div>
        </div>
        </el-dialog>
        <el-dialog
        title="注册"
        :visible.sync="registerVisible"
        width="30%">
        <span>
            <div class="form-group" style="height: 28px;margin-bottom:12px;">
                <label style="width:70px;float:left;line-height:30px;text-align:right;margin-right:10px;">用户名:</label>
                <div style="width:80%;float:left;">
                    <el-input size="mini" v-model.trim="login.UserName" placeholder="请输入用户名" maxlength="64" />
                </div>
            </div>
            <div class="form-group" style="height: 28px;margin-bottom:12px;">
                <label style="width:70px;float:left;line-height:30px;text-align:right;margin-right:10px;">手机号:</label>
                <div style="width:80%;float:left;">
                    <el-input size="mini" v-model.trim="login.Phone" placeholder="请输入手机号" maxlength="64" />
                </div>
            </div>
            <div class="form-group" style="height: 28px;margin-bottom:12px;">
                <label style="width:70px;float:left;line-height:30px;text-align:right;margin-right:10px;">密码:</label>
                <div style="width:80%;float:left;">
                    <el-input size="mini" v-model.trim="login.PassWord" type="PassWord" placeholder="请输入密码" maxlength="64" />
                </div>
            </div>
            <div class="form-group" style="height: 28px;margin-bottom:12px;">
                <label style="width:70px;float:left;line-height:30px;text-align:right;margin-right:10px;">备注:</label>
                <div style="width:80%;float:left;">
                    <el-input size="mini" :autosize="{ minRows: 2, maxRows: 4}" v-model.trim="login.Note" placeholder="请输入备注" maxlength="256" />
                </div>
            </div>
            <div class="form-group" style="height: 28px;margin-bottom:12px;">
                <el-button type="primary" style="width:60%;margin-left:20%;" @click="AddUser">注 册</el-button>
            </div>
        </span>
        </el-dialog>
  </div>
</template>

<script>
export default {
    created(){
        var self =this;
        var heightStr = document.documentElement.clientHeight+'px';
        self.styleObject={
            height:heightStr,
            backgroundImage: "url(" + require("../imgs/login.png") + ")",
            backgroundRepeat: "no-repeat",
            backgroundSize: heightStr+" auto",
            backgroundPosition:'center center'
        };
    },
    components:{},
    data(){
        return{
            styleObject:{
                background:'pink',
            },
            login:{
                Phone:"",
                PassWord:"",
            },
            loginVisible:true,
            registerVisible:false,
        }
    },
    methods:{
        UserLogin(){
            var self =this;
            console.log(process.env.API_ROOT);
            localStorage.setItem('token', JSON.stringify({}));//清除token
            self.$allAxios.SysUser.UserLogin(self.login).then((res)=>{
                if(res.Success){
                    localStorage.setItem('token', JSON.stringify(res.Data));
                    self.$router.push('/');//跳转首页
                }else{
                    self.$message.warning({message: res.Msg});
                }
            });
        },
        AddUser(){
            var self =this;
            localStorage.setItem('token', JSON.stringify({}));//清除token
            self.$allAxios.SysUser.AddUser(self.login).then((res)=>{
                if(res.Success){
                    localStorage.setItem('token', JSON.stringify(res.Data));
                    self.$router.push('/');//跳转首页
                }else{
                    self.$message.warning({message: res.Msg});
                }
            });
        }
    }
}
</script>

<style>
.login{
    height: 100%;
    background:url('../imgs/login.png') no-repeat;
    background-size:60% 100%;
}
</style>