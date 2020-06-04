<template>
  <div>
    <router-link to="/RouterContent/RouterChild">子路由</router-link>
    <button @click="$router.push('/BtContent')">go to 基础</button>
    <button @click="$router.push({name:'BtContent'})">go to 基础</button><!-- 相同名称取第一个 -->
    <br>
    <p style="border:1px solid red"><router-view></router-view></p>
  </div>
</template>

<script>
export default {
    watch: {
        $route(to, from) {
            console.log(to);
            console.log(from);
            console.log(0);
        }
    }
}
</script>