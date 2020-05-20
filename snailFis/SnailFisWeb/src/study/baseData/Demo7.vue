<template>
  <div>
      <div :style="{fontSize:num1+'px'}"><todo-items v-for="item in textArrs" :key="item.title" :todo="item" @changeNum="changeNumss" :sizeNum="num1"></todo-items></div>
  </div>
</template>

<script>
import Vue from "vue";
var todoItems =
    {
        props:['todo','sizeNum'],
        data(){
            return{
                num1:0,
            }
        },
        template:`
            <div>
                <h1>{{todo.title}}</h1>
                <p>{{todo.content}}</P>
                <p>点赞数：{{num1}}</P>
                <button @click="num1++">赞</button>
                <p>文字大小：{{sizeNum}}</P>
                <button @click="$emit('changeNum',2)">变大</button>
            </div>
        `,

    }
export default {
    components:{"todo-items":todoItems},
  data(){
    return{
        textArrs:[{title:"世界和平",content:"希望世界和平，永无战乱"}
        ,{title:"环保",content:"不要让地球的最后一滴水是人类悔恨的泪水"}],
        num1:16,
    }
  },
  methods:{
      changeNumss(size){
        this.num1+=size;
      },
  }
}
</script>
