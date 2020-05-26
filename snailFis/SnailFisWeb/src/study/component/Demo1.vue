<template>
    <div>
        <base-span  ref="aaa" id="a" ></base-span>
        <base-input ref="aaa"  id="b"></base-input>
        <button @click="change">change</button>
    </div>
</template>

<script>
export default {
    props:{
    },
    data(){  
        return{
            bool1:true,
            str1:"",
            str2:"123",
        }
    },
    methods:{ 
        change(){
            console.log(this.$refs)
        }
    }
}
</script>