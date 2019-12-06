import React, { Component } from 'react';
import { Button, Card, CardFooter, CardBody, CardGroup, Col, Container, Form, Input, InputGroup, InputGroupAddon, InputGroupText, Row } from 'react-dom';
export class Reg extends Component {
    displayName = Reg.name
    constructor() {
        super();
        this.state = {
            UserName: '',
            Email: '',
            Password: '',
            City: ''
        }
        this.Email = this.Email.bind(this);
        this.Password = this.Password.bind(this);
        this.UserName = this.UserName.bind(this);
        this.Password = this.Password.bind(this);
        this.City = this.City.bind(this);
        this.register = this.register.bind(this);
    }
    Email(event) {
        this.setState({ Email: event.target.value })
    }
    Password(event) {
        this.setState({ Password: event.target.value })
    }
    City(event) {
        this.setState({ City: event.target.value })
    }
    UserName(event) {
        this.setState({ UserName: event.target.value })
    }
    register(event) {
        fetch('insertreader', {
            method: 'post',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                UserName: this.state.UserName,
                Password: this.state.Password,
                Email: this.state.Email,
                City: this.state.City,
                
            })
        }).then((Response) => Response.json())
            .then((Result) => {
                if (Result.Status == 'Success')
                    this.props.history.push("/library");
                else
                    alert('Sorrrrrry !!!! Un-authenticated User !!!!!')
            })
    }
    render() {
        return (
            <div className="app flex-row align-items-center">
                <Container>
                    <Row className="justify-content-center">
                        <Col md="9" lg="7" xl="6">
                            <Card className="mx-4">
                                <CardBody className="p-4">
                                    <Form>
                                        <div class="row" className="mb-2 pageheading">
                                            <div class="col-sm-12 btn btn-primary">
                                                Sign Up
                        </div>
                                        </div>
                                        <InputGroup className="mb-3">
                                            <Input type="text" onChange={this.UserName} placeholder="Введите имя" />
                                        </InputGroup>
                                        <InputGroup className="mb-3">
                                            <Input type="text" onChange={this.Email} placeholder="Введите Email" />
                                        </InputGroup>
                                        <InputGroup className="mb-3">
                                            <Input type="password" onChange={this.Password} placeholder="Введите пароль" />
                                        </InputGroup>
                                        <InputGroup className="mb-4">
                                            <Input type="text" onChange={this.City} placeholder="Введите город" />
                                        </InputGroup>
                                       
                                        <Button onClick={this.register} color="success" block>Создать аккуант</Button>
                                    </Form>
                                </CardBody>
                            </Card>
                        </Col>
                    </Row>
                </Container>
            </div>
        );
    }
}
