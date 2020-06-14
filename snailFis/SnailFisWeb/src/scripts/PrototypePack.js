import allAxios from "@/scripts/Services.js";

export default {
    initMixins(Vue) {
        Vue.prototype.$allAxios = allAxios;
    }
  };