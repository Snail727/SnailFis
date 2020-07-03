<template>
  <div style="width:100%;height:100%;">
    <div class="menu">
        <el-row class="tac">
            <el-col>
                <el-menu
                style="width:150px;border:0;"
                class="el-menu-vertical-demo"
                background-color="#545c64"
                text-color="#fff"
                active-text-color="#ffd04b">
                    <el-menu-item index="1">
                        <i class="el-icon-menu"></i>
                        <span slot="title" @click="$router.push('/')">首页</span>
                    </el-menu-item>
                    <el-submenu index="2">
                        <template slot="title">
                        <i class="el-icon-location"></i>
                        <span>运动</span>
                        </template>
                        <el-menu-item index="2-1"  @click="$router.push('/Sport')">运动首页</el-menu-item>
                    </el-submenu>
                </el-menu>
            </el-col>
        </el-row>
    </div>
    <div class="main">
        <div class="head">
            <el-button size="small" @click="exit" style="float:right;margin:10px 20px 0 0 ;">退出</el-button>
        </div>
        <div class="body"><keep-alive><router-view></router-view></keep-alive></div>
    </div>
  </div>
</template>

<script>
export default {
    created(){
    },
    components:{},
    data(){
        return{
        }
    },
    methods:{
        exit(){
            var self =this;
            localStorage.setItem('token', JSON.stringify({}));//清除token
            self.$router.push('/Login');//跳转登陆页
        }
    }
}
</script>

<style>
.menu{
    background: #545c64;
    width: 150px;
    height: 100%;
    float: left;
}
.main{
    min-width: 500px;
    height: 100%;
    overflow: hidden;
}
.head{
    background: #545c64;
    height: 50px;
}
.body{
    height: calc(100% - 50px);
}
.el-submenu .el-menu-item {
    min-width: 150px;
}
</style>
