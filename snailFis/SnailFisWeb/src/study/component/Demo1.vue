<template>
    <div>
        <base-span @focus="fun1"></base-span>
    </div>
</template>

<script>
export default {
    props:{
    },
    data(){  
        return{
            str1:"ceshi",
        }
    },
    methods:{ 
        fun1(){
            // alert("help");
            console.log("help");
        }
    }
}
</script>