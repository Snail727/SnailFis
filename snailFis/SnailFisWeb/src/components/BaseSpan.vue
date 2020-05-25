<template>
  <span>{{PostTitle}}<button @click="str1='sdfsdfsdff'">change</button>{{str1}}<button @click="str2='we3234ew'">change</button>{{str2}}</span>
</template>

<script>
export default {
    inheritAttrs: false,
    props:["PostTitle"],
    data(){
        return{
            str1:this.PostTitle,
            str2:"this.str1"
        }
    }
}
</script>
