<template>
  <div>
        <input v-model="str1">
  </div>
</template>

<script>
export default {
    data(){
        return{
            str1:"1",
        }
    },
    methods:{
      change(){
        console.log(this.$root);
        //this.$root.str2="sfsdfsd";
      }
    }
}
</script>
