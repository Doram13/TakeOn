<template>
  <div class="container-fluid">
    <div class="row m-2 p-2 align-items-center"
         v-for="commitment in commitments"
         :key="commitment.id">
      <div class="col align-content-center">
        {{ commitment.content }}
      </div>
    </div>
  </div>
</template>

<script>

export default {
  name: 'Commitment',
  props: ['commitments'],

};
</script>

<style scoped>

</style>
