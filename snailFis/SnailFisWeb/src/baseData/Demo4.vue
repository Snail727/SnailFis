<template>
  <div>
      <ol><li v-for="(model,index) in liList" :key="model.name">{{index}}---{{model.name}}</li></ol>
      <button @click="pushData">添加数据</button>
      <ol><li v-for="(model,name,index) of userObj" :key="model.name">{{index}}---{{name}}---{{model}}</li></ol>
      <ol><li v-for="n in 10" :key="n">{{n}}</li></ol>
      <todo-item v-for="n of 9" :key="n"></todo-item>
  </div>
</template>

<script>
import Vue from "vue";
Vue.component('todo-item',{template:'<div>你好</div>'})
export default {
  data(){
    return{
        liList:[{name:"a"},{name:"b"},{name:"c"}],
        userObj:{
            name:"小红",
            age:"28",
            note:"强壮"
        }
    }
  },
  methods:{
    pushData(){
      this.liList.push({name:'d'});
    },
  }
}
</script>
