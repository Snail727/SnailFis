<template>
  <div style="width:100%;height:100%;">
    <div class="menu">
        <router-link :to="{path:'/'}">首页</router-link>
        <router-link :to="{path:'/Sport'}">运动</router-link>
    </div>
    <div class="main">
        <div class="head"><button @click="exit">退出</button></div>
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
    width: 100px;
    height: 100%;
    float: left;
}
.main{
    min-width: 500px;
    height: 100%;
    overflow: hidden;
}
.head{
    height: 30px;
}
.body{
    height: calc(100% - 30px);
}
</style>
