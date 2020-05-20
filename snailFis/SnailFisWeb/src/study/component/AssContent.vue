<template>
  <div>
    <button @click="id=0">Go to demo(介绍)</button>
    <button @click="id=1">Go to demo(模板语法、计算属性和侦听器)</button>
    
    <div style="border:1px solid orange;">
        <demo v-if="id==0"></demo>
        <demo1 v-else-if="id==1"></demo1>
    </div>
  </div>
</template>

<script>
import demo from "./Demo.vue";
import demo1 from "./Demo1.vue";
export default {
    components:{demo,demo1},
    data(){
        return{
        id:0
        }
    },
    methods:{
    }
}
</script>