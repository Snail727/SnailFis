import Vue from 'vue'
import Router from 'vue-router'
import HelloWorld from '@/components/HelloWorld'
import BtContent from '@/study/baseData/BtContent'
import AssContent from '@/study/component/AssContent'

Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/',
      name: 'HelloWorld',
      component: HelloWorld
    },
    {
      path: '/BtContent',
      name: 'BtContent',
      component: BtContent
    },
    {
      path: '/AssContent',
      name: 'AssContent',
      component: AssContent
    }
  ]
})
