<template>
  <div>
    <button @click="id=0">Go to demo(组件注册、prop)</button>
    <button @click="id=1">Go to demo(自定义事件)</button>
    <button @click="id=2">Go to demo(样式过度)</button>
    <button @click="id=3">Go to demo(过滤器)</button>
    
    <div style="border:1px solid orange;">
        <demo v-if="id==0"></demo>
        <demo1 v-else-if="id==1"></demo1>
        <demo2 v-else-if="id==2"></demo2>
        <demo3 v-else-if="id==3"></demo3>
    </div>
  </div>
</template>

<script>
import demo from "@/study/component/Demo.vue";
import demo1 from "@/study/component/Demo1.vue";
import demo2 from "@/study/component/Demo2.vue";
import demo3 from "@/study/component/Demo3.vue";
export default {
    components:{demo,demo1,demo2,demo3},
    data(){
        return{
        id:0
        }
    },
    methods:{
    }
}
</script>