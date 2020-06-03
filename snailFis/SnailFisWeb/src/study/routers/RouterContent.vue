<template>
  <div>
    <button>submit</button>
    <router-link :to="{path:'/Demo1/1/你好',query:{searchText:'模糊'}}">动态路由</router-link>
    <router-link :to="{path:'/Demo2/2/你好',query:{searchText:'模糊'}}">动态路由</router-link>
    <br>
    <router-view></router-view>
  </div>
</template>

<script>
import Vue from 'vue'
import Demo1 from "./Demo1"
import Demo2 from "./Demo2"
import VueRouter from 'vue-router'
Vue.use(VueRouter)
const router = new VueRouter({
    routes:[
        {path:"/Demo2/:id/:name",component:Demo2},
        {path:"/Demo*/:id/:name",component:Demo1},
    ]
})
export default {
    router,
    data(){
        return{
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