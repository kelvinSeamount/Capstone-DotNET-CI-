![alt text](<FLow Diagaram.png>)


Overview

This repository contains the Continuous Integration (CI) pipeline for a .NET application. The pipeline implements security scanning, code quality analysis, automated builds, containerization, and image scanning before triggering the deployment process.


The entire AWS infrastructure for this project is managed as code using Terraform in a separate repository.https://github.com/kelvinSeamount/Capstone-Infrastructure


Deployment Flow

    Local Development Developers develop and test code locally   

    Source Control Code merged to main branch triggers the CI pipeline

    CI Process Automated security scanning, build, and containerization

    Post-Build Update CD repository and send notifications


CI/CD Tools

    Jenkins CI automation server running on EC2

    GitHub Source code management

    Docker Containerization platform


Security & Quality Tools

    GitLeaks Secret detection and credential scanning

    Dependency Check Vulnerability scanning for dependencies

    SonarQube Static code analysis and code quality metrics

    Trivy Container image vulnerability scanning


Build Tools

    .NET SDK Application build framework

    Docker Container image creation


Email Notifications

    Build Status Success/Failure with color-coded banners (green/red)

    Job Information Job name and build number

    Console Link Direct link to build output

    HTML Formatting Professional, easy-to-read format
