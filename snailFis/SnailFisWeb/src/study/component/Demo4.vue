<template>
    <div>
        <input v-focus>
    </div>
</template>

<script>
export default {
    data(){  
        return{
            num1:1,
        }
    },
    filters:{
        numChange(value1,value2){
            return value1+1;
        }
    }
}
</script>