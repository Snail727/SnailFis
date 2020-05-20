<template>
  <div>
    <button @click="id=0">Go to demo(介绍)</button>
    <button @click="id=1">Go to demo(模板语法、计算属性和侦听器)</button>
    <button @click="id=2">Go to demo(样式绑定)</button>
    <button @click="id=3">Go to demo(条件渲染)</button>
    <button @click="id=4">Go to demo(列表渲染)</button>
    <button @click="id=5">Go to demo(事件处理)</button>
    <button @click="id=6">Go to demo(表单输入绑定)</button>
    <button @click="id=7">Go to demo(组件基础)</button>
    
    <div style="border:1px solid orange;">
        <demo v-if="id==0"></demo>
        <demo1 v-else-if="id==1"></demo1>
        <demo2 v-else-if="id==2"></demo2>
        <demo3 v-else-if="id==3"></demo3>
        <demo4 v-else-if="id==4"></demo4>
        <demo5 v-else-if="id==5"></demo5>
        <demo6 v-else-if="id==6"></demo6>
        <demo7 v-else-if="id==7"></demo7>
    </div>
  </div>
</template>

<script>
import demo from "./Demo.vue";
import demo1 from "./Demo1.vue";
import demo2 from "./Demo2.vue";
import demo3 from "./Demo3.vue";
import demo4 from "./Demo4.vue";
import demo5 from "./Demo5.vue";
import demo6 from "./Demo6.vue";
import demo7 from "./Demo7.vue";
export default {
    components:{demo,demo1,demo2,demo3,demo4,demo5,demo6,demo7},
    data(){
        return{
        id:0
        }
    },
    methods:{
    }
}
</script>