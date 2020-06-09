<template>
  <div>
    <button v-for="tab in tabStrs" :key="tab.id" @click="tabName=tab.id">{{tab.name}}</button>
    <div style="border:1px solid orange;">
        <keep-alive><component :is="tabName"></component></keep-alive>
    </div>
  </div>
</template>

<script>
import demo from "@/study/vuexs/Demo.vue";
import demo1 from "@/study/vuexs/Demo1.vue";
import demo2 from "@/study/vuexs/Demo2.vue";
export default {
  components:{demo,demo1,demo2},
  data(){
    return{
      tabStrs:[
        {id:"demo",name:"简单store"},
        {id:"demo1",name:"Getter、Mutation、Action"},
        {id:"demo2",name:"modules"},
      ],
      tabName:"demo",
    }
  }
}
</script>