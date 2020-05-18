<template>
  <div id="app">
  <h1>Hello App!</h1>
  <p>
    <router-link to="/Demo">Go to demo(介绍)</router-link>
    <router-link to="/Demo1">Go to demo(模板语法、计算属性和侦听器)</router-link>
    <router-link to="/Demo2">Go to demo(样式绑定)</router-link>
    <router-link to="/Demo3">Go to demo(条件渲染)</router-link>
    <router-link to="/Demo4">Go to demo(列表渲染)</router-link>
  </p>
  <div style="border: 1px solid red;">
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
