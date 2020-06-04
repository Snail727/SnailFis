<template>
  <div>
    <router-link :to="{path:'/Demo1/1/你好',query:{searchText:'模糊'}}">动态路由</router-link>
    <router-link :to="{path:'/Demo2/2/你好',query:{searchText:'模糊'}}">动态路由</router-link>
    <button @click="$router.push({name:'Demo3',params:{str1}})">push to Demo3</button>
    <button @click="$router.replace({name:'Demo3',params:{str1}})">replace to Demo3</button>
    <button @click="gotoDemo2">go to Demo2</button>
    <button @click="$router.push('/Demo4')">go to Demo4</button>
    <button @click="$router.push('/Demo5')">go to Demo5</button>
    <br>
    <router-view></router-view>
  </div>
</template>

<script>
import Vue from 'vue'
import Demo1 from "./Demo1"
import Demo2 from "./Demo2"
import Demo3 from "./Demo3"
import Demo4 from "./Demo4"
import Demo5 from "./Demo5"
import VueRouter from 'vue-router'
Vue.use(VueRouter)
const router = new VueRouter({
    routes:[
        {path:"/Demo2/:id/:name",component:Demo2},
        {path:"/Demo3",component:Demo3,name:'Demo3'},
        {path:"/Demo4",redirect:'/Demo5'},
        {path:"/Demo5",component:Demo5},
        {path:"/Demo*/:id/:name",component:Demo1},
    ]
})
export default {
    router,
    data(){
        return{
            str1:'123'
        }
    },
    methods:{
        gotoDemo2(){
            var self =this;
            self.$router.push({path:`/Demo2/${self.str1}/你好`});
        }
    },
    watch: {
        $route(to, from) {
            console.log(to);
            console.log(from);
            console.log(0);
        }
    }
}
</script>