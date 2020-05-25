<template>
  <span>{{testStr}}<button @click="str1='sdfsdfsdff'">change</button></span>
</template>

<script>
export default {
    props:["testStr"],
    data(){
        return{
            str1:"",
        }
    },
    watch:{
        str1:function(newVal){
            this.$emit('update:test-str',newVal)
        }
    },
}
</script>
