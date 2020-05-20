<template>
  <div>
    <span>data1:{{data1}}</span><br>
    <span v-bind:title="data2">data2:鼠标悬停</span><br>
    <span>data3:<span v-if="data3">被控制显示是否隐藏</span><button @click="data3=false">隐藏</button><button @click="data3=true">显示</button></span><br>
    <span>data4:<ol><li :key=i v-for="(item,i) in data4" >{{item.text}}</li></ol></span><br>
    <span>data5:{{data5}}<button v-on:click="reverse">反转</button></span><br>
    <span>data6:{{data6}}<input v-model="data6"></span><br>
    <span>data7:<ol><todo-items :todo="data7"></todo-items></ol></span><br>
  </div>
</template>

<script>
import Vue from "vue";
Vue.component('todo-items',{props:['todo'],template:'<li>{{todo.text}}</li>'})
export default {
  data(){
    return{
      data1:'Hello Vue!',
      data2:'页面加载于 ' + new Date().toLocaleString(),
      data3:true,
      data4:[
        { text: '学习 JavaScript' },
        { text: '学习 Vue' },
        { text: '整个牛项目' }
        ],
      data5:'Hello Vue.js!',
      data6:'双向绑定',
      data7:{text:'组件组件我爱你'}
    }
  },
  methods:{
    reverse(){
      this.data5 = this.data5.split('').reverse().join('')
    }
  }
}
</script>