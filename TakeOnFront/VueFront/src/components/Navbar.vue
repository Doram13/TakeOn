<template>
  <div>
    <b-navbar fixed="top" toggleable="lg" type="light" variant="light" >
      <b-navbar-brand :to="{ name: 'Home' }">TakeOff</b-navbar-brand>
      <b-navbar-toggle target="nav-collapse"></b-navbar-toggle>
      <b-collapse id="nav-collapse" is-nav>
        <b-navbar-nav>
          <b-nav-item href="#">Retro</b-nav-item>
          <b-nav-item href="#">Tegnap</b-nav-item>
        </b-navbar-nav>

        <!-- Right aligned nav items -->
        <b-navbar-nav class="ml-auto">

          <b-nav-item-dropdown right>
            <!-- Using 'button-content' slot -->
            <template slot="button-content"><em>User</em></template>
            <b-dropdown-item v-if="user !== ''">{{user}}</b-dropdown-item>
            <b-dropdown-item v-b-modal.login-modal v-if="user === ''">
              Login
              <b-modal id="login-modal" title="Please log in">
                <div>
                  <b-form-group
                    id="login-form"
                    :invalid-feedback="invalidFeedback"
                    :valid-feedback="validFeedback"
                    :state="state">
                    <b-form-input placeholder="email"
                                  id="input-name"
                                  v-model="name"
                                  :state="state"
                                  trim>email</b-form-input>
                    <b-form-input placeholder="password"
                                  id="input-password"
                                  v-model="password"
                                  :state="state" trim>password</b-form-input>
                  </b-form-group>
                </div>
              </b-modal>
            </b-dropdown-item>
            <b-dropdown-item v-b-modal.register-modal v-if="user === ''">
              Register
              <b-modal id="register-modal" title="Please register">
                <div>
                  <b-form-group
                    id="register-form"
                    :invalid-feedback="invalidFeedback"
                    :valid-feedback="validFeedback"
                    :state="state">
                    <b-form-input placeholder="email"
                                  id="input-name-reg"
                                  v-model="name"
                                  :state="state"
                                  trim>email</b-form-input>
                    <b-form-input placeholder="password"
                                  id="input-password-reg"
                                  v-model="password"
                                  :state="state" trim>password</b-form-input>
                  </b-form-group>
                </div>
              </b-modal></b-dropdown-item>
            <b-dropdown-item v-if="user !== ''">Log out</b-dropdown-item>
          </b-nav-item-dropdown>
        </b-navbar-nav>
      </b-collapse>
    </b-navbar>
  </div>
</template>
<script>

export default {
  name: 'Navbar',
  props: [
    'user',
  ],
  data() {
    return {
      date: new Date(Date.now()),
    };
  },
};
</script>

<style scoped>

</style>
