<template>
  <div class="container-fluid">
    <div class="row m-2 p-2"
         v-for="question in questions"
         :key="question.id">
      {{ question.content }}</div>
  </div>
</template>

<script>

export default {
  name: 'Questions',
  props: ['questions'],
};
</script>

<style scoped>

</style>
