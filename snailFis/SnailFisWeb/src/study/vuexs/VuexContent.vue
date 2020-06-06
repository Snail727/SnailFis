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
export default {
  components:{demo},
  data(){
    return{
      tabStrs:[
        {id:"demo",name:"简单store"},
      ],
      tabName:"demo",
    }
  }
}
</script>