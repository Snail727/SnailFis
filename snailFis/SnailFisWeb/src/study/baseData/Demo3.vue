<template>
  <div>
      <div v-if="isTitle">你好呀</div>
      <div v-else>这是一个题目</div>
      <template v-if="mathNum>0.5"><p>我大于0.5</p></template>
      <template v-else-if="mathNum==0.5"><p>我等于0.5</p></template>
      <template v-else><p>我小于0.5</p></template>
      <div>
        <template v-if="isUser">
            <label>userName</label>
            <input key="email">
        </template>
        <template v-else>
            <label>email</label>
            <input key="email">
        </template>
        <button @click="isUser=!isUser">change</button>
        <div v-show="isTitle">你好呀</div>
      </div>
  </div>
</template>

<script>
export default {
  data(){
    return{
        isTitle:false,
        mathNum:Math.random(),
        isUser:true,
    }
  }
}
</script>
