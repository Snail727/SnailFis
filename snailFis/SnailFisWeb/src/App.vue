<template>
  <div id="app">
  <h1>Hello App!</h1>
  <p style="border:1px solid orange">
    <button @click="$router.go(-1)">go back</button>
    <router-link to="/BtContent">Go to demo(基础)</router-link>
    <router-link to="/AssContent">Go to demo(组件)</router-link>
    <router-link to="/RouterContent">Go to demo(路由)</router-link>
    <router-link to="/VuexContent">Go to demo(Vuex)</router-link>
  </p>
  <div style="border:1px solid red;float:left;width:10%;">
  <router-view name="menu"></router-view>
  </div>
  <div style="border:1px solid blue;float:left;width:80%;">
  <router-view></router-view>
  </div>
</div>
</template>

<script>
export default {
  name: 'App'
}
</script>

<style>
#app {
  font-family: 'Avenir', Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
</style>
