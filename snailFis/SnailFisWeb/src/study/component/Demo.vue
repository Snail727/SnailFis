<template>
  <div>
    <div><first-component></first-component></div>
    <div><second-component></second-component></div>
  </div>
</template>

<script>
import Vue from "vue";
Vue.component('first-component',{template:'<span>第一个组件,全局类型</span>'})//创建全局组件，需要引入vue
var SecondComponent ={template:'<span>第二个组件，局部类型</span>'}
export default {
  components:{"second-component":SecondComponent},
  data(){
    return{
    }
  },
  methods:{
  }
}
</script>