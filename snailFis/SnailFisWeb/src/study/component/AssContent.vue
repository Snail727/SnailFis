<template>
  <div>
    <button v-for="tab in tabStrs" :key="tab.id" @click="tabName=tab.id">{{tab.name}}</button>
    <div style="border:1px solid orange;">
        <keep-alive><component :is="tabName"></component></keep-alive>
    </div>
  </div>
</template>

<script>
import demo from "@/study/component/Demo.vue";
import demo1 from "@/study/component/Demo1.vue";
import demo2 from "@/study/component/Demo2.vue";
import demo3 from "@/study/component/Demo3.vue";
import demo4 from "@/study/component/Demo4.vue";
//import demo5 from "@/study/component/Demo5.vue";
export default {
  components:{demo,demo1,demo2,demo3,demo4},
  data(){
    return{
      tabStrs:[
        {id:"demo",name:"组件注册、prop"},
        {id:"demo1",name:"自定义事件"},
        {id:"demo2",name:"样式过渡"},
        {id:"demo3",name:"过滤器"},
        {id:"demo4",name:"自定义指令和渲染函数"},
        //{id:"demo5",name:"ts"},
      ],
      tabName:"demo",
    }
  }
}
</script>