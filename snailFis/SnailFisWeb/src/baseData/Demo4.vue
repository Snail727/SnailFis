<template>
  <div>
      <ol><li v-for="(model,index) in liList" :key="model.name">{{index}}---{{model.name}}</li></ol>
      <!-- <button @click="liList.push({name:'d'})"><button> -->
      <ol><li v-for="(model,name,index) in userObj" :key="model.name">{{index}}---{{name}}---{{model}}</li></ol>
  </div>
</template>

<script>
export default {
  data(){
    return{
        liList:[{name:"a"},{name:"b"},{name:"c"}],
        userObj:{
            name:"小红",
            age:"28",
            note:"强壮"
        }
    }
  }
}
</script>
