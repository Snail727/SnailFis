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

过滤器可以用在两个地方：双花括号插值和 v-bind 表达式 (后者从 2.1.0+ 开始支持)。过滤器应该被添加在 JavaScript 表达式的尾部，由“管道”符号指示