<template>
  <div class="container-fluid">
    <div class="m-2 p-2" v-for="answer in answers" :key="answer.content">{{ answer.content }}</div>
  </div>
</template>

<script>
export default {
  name: 'Answers',
  props: ['answers'],
};
</script>

<style scoped>

</style>
