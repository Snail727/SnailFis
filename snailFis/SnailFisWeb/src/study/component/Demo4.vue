<template>
    <div>
        {{num1 | numChange(num1) | numChange(num1)}}{{num1}}
        {{num1+1 | numChange }}
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