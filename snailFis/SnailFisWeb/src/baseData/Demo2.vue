<template>
  <div>
    <div :class="{class1:isClass1,class2:isClass2}">你好</div>
    <div :class="classObject">你好</div>
    <div :class="[className1,className2]">你好</div>
    <div :class="[isClass1?className1:'']">你好</div>
    <div :class="[{'class1':isClass1},className2]">你好</div>
    <todo-item :class="[isClass1?className1:'']"></todo-item>
    <div :style="styleObject">你好</div>
  </div>
</template>

<script>
import Vue from "vue";
Vue.component('todo-item',{template:'<div>你好</div>'})
export default {
  data(){
    return{
      isClass1:true,
      isClass2:true,
      classObject:{
          class1:true,
          class2:false
      },
      className1:"class1",
      className2:"class2",
      styleObject:{
          background:'pink',
      },
    }
  }
}
</script>

<style>
.class1{
    background: red;
}
.class2{
    background: pink;
}
</style>
